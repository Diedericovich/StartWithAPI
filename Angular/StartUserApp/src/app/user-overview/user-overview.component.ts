import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { user} from '../user';

@Component({
  selector: 'app-user-overview',
  templateUrl: './user-overview.component.html',
  styleUrls: ['./user-overview.component.css']
})
export class UserOverviewComponent implements OnInit {
  users: user[] = [];
  selectedUser?:user;


  constructor(
    private userService: UserService) { }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers(): void {
    this.userService.getUsers()
      .subscribe(x => this.users = x);
  }

  add(name: string) {
    name = name.trim();
    if (!name) {return;}

    this.userService.addUser({name} as user)
        .subscribe(x => this.users.push((x)));
  }

  deleteUser(user: user) {
    if (!user) {return;}

    this.userService.deleteUser(user)
          .subscribe(() => this.users = this.users.filter(x => x != user));
  }




}
