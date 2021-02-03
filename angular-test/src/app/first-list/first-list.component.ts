import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-first-list',
  templateUrl: './first-list.component.html',
  styleUrls: ['./first-list.component.scss']
})
export class FirstListComponent implements OnInit {

  constructor() { }
  listy = ['ana', 'miau', 'biau'];

  ngOnInit(): void {
  }

}
