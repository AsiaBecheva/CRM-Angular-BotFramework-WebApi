import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import 'rxjs/add/operator/map';

const baseUrl = 'http://localhost:54735/'

@Injectable()
export class HttpService {
    constructor(private http: Http) { }

    post(url: any, data: any) {
        return this.http
            .post(`${baseUrl}${url}`, JSON.stringify(data))
            .map(res => res.json());
    }
}