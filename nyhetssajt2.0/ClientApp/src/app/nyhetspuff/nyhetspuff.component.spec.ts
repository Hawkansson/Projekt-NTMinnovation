import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NyhetspuffComponent } from './nyhetspuff.component';

describe('NyhetspuffComponent', () => {
  let component: NyhetspuffComponent;
  let fixture: ComponentFixture<NyhetspuffComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NyhetspuffComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NyhetspuffComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
