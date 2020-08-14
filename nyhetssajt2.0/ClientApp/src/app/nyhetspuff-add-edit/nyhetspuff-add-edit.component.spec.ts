import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NyhetspuffAddEditComponent } from './nyhetspuff-add-edit.component';

describe('NyhetspuffAddEditComponent', () => {
  let component: NyhetspuffAddEditComponent;
  let fixture: ComponentFixture<NyhetspuffAddEditComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NyhetspuffAddEditComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NyhetspuffAddEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
