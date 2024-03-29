import { Component, OnInit } from '@angular/core';
import icSchool from '@iconify/icons-ic/twotone-account-balance';
import icStudents from '@iconify/icons-ic/twotone-school';
import icUsers from '@iconify/icons-ic/twotone-people';
import icSchedule from '@iconify/icons-ic/twotone-date-range';
import icGrade from '@iconify/icons-ic/twotone-leaderboard';
import icAttendance from '@iconify/icons-ic/twotone-access-alarm';

@Component({
  selector: 'vex-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.scss']
})
export class SettingsComponent implements OnInit {

  icSchool = icSchool;
  icStudents = icStudents;
  icUsers = icUsers;
  icSchedule = icSchedule;
  icGrade = icGrade;
  icAttendance = icAttendance;

  constructor() { }

  ngOnInit(): void {
  }
  setPageId(pageId = 'Period'){
    localStorage.setItem("pageId", pageId);
  }
}
