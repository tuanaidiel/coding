import { Component, OnInit } from '@angular/core';
import { GreetingService } from './greeting.service';

@Component({
    selector: 'app-greeting',
    templateUrl: './greeting.component.html',
    styleUrls: ['./greeting.component.css']
})

export class  GreetingComponent {
    name: string = "Aidiel";

    constructor(private greetingService: GreetingService) {}

    ngOnInit(): void {
        this.greetingService.getGreeting().subscribe(data => {
            this.name = data.name;
        })
    }

    clearName() {
        this.name = '';
    }
}
