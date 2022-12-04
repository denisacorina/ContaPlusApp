import { Component } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {

model : any ={};
registered = true;  

  constructor(private auth : AuthService) { }

  ngOnInit(): void {
   
  }


submitData()
{
  let body = {
    firstName : this.model.firstName,
    lastName : this.model.lastName,
    email : this.model.email,
    password : this.model.password
  }

  this.auth.register(body).subscribe(
    res => console.log(res)
  )
}
}
