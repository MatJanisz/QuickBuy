import { Category } from './../../shared/enums/category.enum';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-find',
  templateUrl: './find.component.html',
  styleUrls: ['./find.component.css']
})
export class FindComponent implements OnInit {
  keyword: string;
  category: string;
  constructor(
    private route: ActivatedRoute,
  ) {
    this.route.params.subscribe((params: Params) => {
      if (params['category'] === undefined) {
        this.category = '';
      } else {
        this.category = '' + params['category'];
      }
      if (params['keyword'] === undefined) {
        this.keyword = '';
      } else {
        this.keyword = '' + params['keyword'];
      }
    });
  }
  ngOnInit() {
  }

}
