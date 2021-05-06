import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
import { user } from './user';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }
  private usersUrl = 'api/users';
    httpOptions = {
      headers: new HttpHeaders({'Content-Type':'application/json'})
    };

    getUser(id: number): Observable<user> {
      const url = `${this.usersUrl}/${id}`;
      const user = this.http.get<user>(url);
      return user;
    }

    getUsers(): Observable<user[]>{
      const users = this.http.get<user[]>(this.usersUrl);
      return users;
    }

    addUser(user: user): Observable<user>{
      return this.http.post<user>(this.usersUrl, user, this.httpOptions);
    } 

    updateUser(user: user| undefined): Observable<any> {
      return this.http.put(this.usersUrl, user, this.httpOptions);
    }

    deleteUser(user: user): Observable<user> {
      const url = `${this.usersUrl}/${user.id}`;
      return this.http.delete<user>(url, this.httpOptions);
    }











}
