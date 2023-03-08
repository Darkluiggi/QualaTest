import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'QualaTest';
  isShowing: boolean = true;

  toggleSidenav() {
     this.isShowing = !this.isShowing;
  }
}
