import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewDetailFileComponent } from './view-detail-file.component';

describe('ViewDetailFileComponent', () => {
  let component: ViewDetailFileComponent;
  let fixture: ComponentFixture<ViewDetailFileComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ViewDetailFileComponent]
    });
    fixture = TestBed.createComponent(ViewDetailFileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
