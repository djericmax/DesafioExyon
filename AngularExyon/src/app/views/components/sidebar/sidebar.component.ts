import { Component, OnInit, ViewEncapsulation } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css'],
  // Need to remove view encapsulation so that the custom tooltip style defined in
  // `tooltip-custom-class-example.css` will not be scoped to this component's view.
  encapsulation: ViewEncapsulation.None,
})
export class SidebarComponent implements OnInit {

  public titulo = 'Sistema para gerenciamento de passagens aéreas - E-XYON';
  constructor() { }

  ngOnInit(): void {
  }

}
