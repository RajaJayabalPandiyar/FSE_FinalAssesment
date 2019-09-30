import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectManagerTaskComponent } from './project-manager-task.component';

describe('ProjectManagerTaskComponent', () => {
  let component: ProjectManagerTaskComponent;
  let fixture: ComponentFixture<ProjectManagerTaskComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProjectManagerTaskComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProjectManagerTaskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
