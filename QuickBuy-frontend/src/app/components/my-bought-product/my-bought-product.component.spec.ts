import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MyBoughtProductComponent } from './my-bought-product.component';

describe('MyBoughtProductComponent', () => {
  let component: MyBoughtProductComponent;
  let fixture: ComponentFixture<MyBoughtProductComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MyBoughtProductComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MyBoughtProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
