import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})

export class GreetingService {
    constructor (private http: HttpClient) {}

    getGreeting(): Observable<any> {
        //simulate call to an API
        return this.http.get<any>('https://api.example.com/greeting');
    }
}
