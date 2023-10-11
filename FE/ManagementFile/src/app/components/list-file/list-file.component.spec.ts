import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListFileComponent } from './list-file.component';

describe('ListFileComponent', () => {
  let component: ListFileComponent;
  let fixture: ComponentFixture<ListFileComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ListFileComponent]
    });
    fixture = TestBed.createComponent(ListFileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
