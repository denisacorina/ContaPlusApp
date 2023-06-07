using ContaPlusAPI.Interfaces.IRepository.AccountingRepositoryInterface;
using ContaPlusAPI.Models.AccountingModule;
using ContaPlusAPI.Services.InventoryModuleService;

namespace ContaPlusAPI.Helpers
{
    public class BackgroundOverdueCheckTask : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private Timer _timer;
        private readonly ILogger<BackgroundOverdueCheckTask> _logger;

        public BackgroundOverdueCheckTask(IServiceProvider serviceProvider, ILogger<BackgroundOverdueCheckTask> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await CheckOverdueTransactions(stoppingToken);

            _timer = new Timer(async _ => await CheckOverdueTransactions(stoppingToken),
                null,
                TimeSpan.Zero,
                TimeSpan.FromHours(24));
            _logger.LogInformation("Task Executed", DateTime.UtcNow.ToLongTimeString());
        }

        private async Task CheckOverdueTransactions(CancellationToken cancellationToken)
        {
            using (var scope = _serviceProvider.CreateScope())
            {
                var _transactionRepository = scope.ServiceProvider.GetRequiredService<ITransactionRepository>();

                ICollection<Transaction> transactions = await _transactionRepository.GetAllTransactions();

                foreach (Transaction transaction in transactions)
                {
                    if (transaction.DueDate.Date < DateTime.Today && transaction.PaymentStatus != PaymentStatus.Paid)
                    {
                        transaction.PaymentStatus = PaymentStatus.Overdue;

                        await _transactionRepository.UpdateTransaction(transaction);
                    }
                }
            }
        }

        public override async Task StopAsync(CancellationToken stoppingToken)
        {
            _timer?.Dispose();

            await base.StopAsync(stoppingToken);
        }
    }
}
