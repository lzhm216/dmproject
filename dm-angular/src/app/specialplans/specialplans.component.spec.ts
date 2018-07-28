import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SpecialplansComponent } from './specialplans.component';

describe('SpecialplansComponent', () => {
  let component: SpecialplansComponent;
  let fixture: ComponentFixture<SpecialplansComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SpecialplansComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SpecialplansComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
