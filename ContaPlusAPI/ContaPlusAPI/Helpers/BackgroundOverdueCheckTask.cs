using ContaPlusAPI.Interfaces.IRepository.AccountingRepositoryInterface;
using ContaPlusAPI.Models.AccountingModule;

namespace ContaPlusAPI.Helpers
{
    public class BackgroundOverdueCheckTask : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private Timer _timer;

        public BackgroundOverdueCheckTask(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            await CheckOverdueTransactions(stoppingToken);

            _timer = new Timer(async _ => await CheckOverdueTransactions(stoppingToken),
                null,
                TimeSpan.Zero,
                TimeSpan.FromHours(24));
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
