import { Component } from "@angular/core";

@Component({
    selector: 'app-counter',
    templateUrl: './counter.component.html',
})

export class CounterComponent {
    counter: number = 0;

    increment() {
        this.counter++;
    }

    decrement() {
        if (this.counter > 0) {
            this.counter--;
        }
    }
}