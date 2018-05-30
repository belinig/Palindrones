import { Component, Inject, OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http'

@Component({
    selector: 'palindrones',
    templateUrl: './palindrones.component.html',
    styleUrls: ['./palindrones.component.css']
})
export class PalindronesComponent implements OnInit {
    public palindrones: string[] = [];


    constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
      
    }

    public ngOnInit() {
        this.load();
    }

    public add(palindrone: string) {
        this.http.post(this.baseUrl + 'api/Palindrones', { "palindrone": palindrone }).subscribe(result => {
            console.log("post result=" + result);
            this.load();
        }, error => console.error(error));
    }

    public load() {
        this.http.get(this.baseUrl + 'api/Palindrones').subscribe(result => {
            this.palindrones = result as string[];
        }, error => console.error(error));
    }
}
