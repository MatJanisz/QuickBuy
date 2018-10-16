import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MyBoughtProductListComponent } from './my-bought-product-list.component';

describe('MyBoughtProductListComponent', () => {
  let component: MyBoughtProductListComponent;
  let fixture: ComponentFixture<MyBoughtProductListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MyBoughtProductListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MyBoughtProductListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
