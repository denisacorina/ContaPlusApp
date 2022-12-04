import { Component, OnInit} from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {};
  loggedIn = false;

  constructor(private auth: AuthService){}
  ngOnInit(): void {
   
  }


  login()
  {
    this.auth.login(this.model).subscribe({
      next: response => {
        console.log(response);
        this.loggedIn=true;
      },
      error: err => console.log(err)
    })
  }
}


