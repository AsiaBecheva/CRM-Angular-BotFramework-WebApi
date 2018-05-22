import { Injectable } from '@angular/core';
import { Http } from '@angular/http';

@Injectable()
export class HttpService {
    constructor(private http: Http) { }

    post(url: any, data: any) {
        return this.http
            .post(url, JSON.stringify(data))
            .subscribe(res => res.json());
    }
}