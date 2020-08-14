import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NyhetsfeedComponent } from './nyhetsfeed.component';

describe('NyhetsfeedComponent', () => {
  let component: NyhetsfeedComponent;
  let fixture: ComponentFixture<NyhetsfeedComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NyhetsfeedComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NyhetsfeedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
