import { Component } from '@angular/core';

@Component({
    selector: 'palindrones',
    templateUrl: './palindrones.component.html',
    styleUrls: ['./palindrones.component.css']
})
export class PalindronesComponent {
    public palindrones: string[] = [];


    public add(palindrone: string) {
        this.palindrones.push(palindrone);
    }
}
