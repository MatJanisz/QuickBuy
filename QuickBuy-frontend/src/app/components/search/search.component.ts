import { Component, OnInit } from '@angular/core';
import { Category } from '../../shared/enums/category.enum';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  category = '';
  constructor(private router: Router, private route: ActivatedRoute) { }

  ngOnInit() {
  }
  selectChangeHandler (event: any) {
    this.category = event.target.value;
  }
  onSearch(input: string) {
    if (input === undefined) {
      input = '';
    }
    if (this.category === '') {
      this.router.navigateByUrl('/find/' +  input);
    } else {
      this.router.navigateByUrl('/find/' + this.category + '/' + input);
    }
  }

}
