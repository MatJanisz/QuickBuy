import { Component, OnInit } from '@angular/core';
import { Category } from '../../shared/enums/category.enum';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  category = 'abc';
  constructor() { }

  ngOnInit() {
  }
  selectChangeHandler (event: any) {
    this.category = event.target.value;
  }
  onSearch(input: string) {
     console.log(input);
   /* if (input === undefined) {
      input = '';
    }
    this.router.navigateByUrl('/find/' + input); */
  }

}
