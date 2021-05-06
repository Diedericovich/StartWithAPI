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

  }

  getHeroes(): void {
    this.userService.getUsers()
      .subscribe(x => this.users = x);
  }


  add(name: string) {
    name = name.trim();
    if (!name) {return;}

    this.heroService.addHero({name} as Hero)
        .subscribe(x => this.heroes.push((x)));
  }

  deleteHero(hero: Hero) {
    if (!hero) {return;}

    this.heroService.deleteHero(hero)
          .subscribe(() => this.heroes = this.heroes.filter(x => x != hero));
  }




}
