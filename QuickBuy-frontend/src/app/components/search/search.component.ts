import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  constructor() { }

  ngOnInit() {
  }
  onSearch(input: string) {
     console.log(input);
   /* if (input === undefined) {
      input = '';
    }
    this.router.navigateByUrl('/find/' + input); */
  }

}
