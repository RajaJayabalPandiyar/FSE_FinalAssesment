import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectManagerUserComponent } from './project-manager-user.component';

describe('PopsSupplierComponent', () => {
  let component: ProjectManagerUserComponent;
  let fixture: ComponentFixture<ProjectManagerUserComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProjectManagerUserComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjectManagerUserComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
