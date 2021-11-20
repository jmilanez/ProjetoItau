import { Component } from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Projeto-Itau';

  constructor(private router: Router) {}

  ngOnInit() {
  }
  
  hasRoute(route: string) {
    return this.router.url.includes(route);
  }
}
