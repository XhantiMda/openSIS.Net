import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import icClose from '@iconify/icons-ic/twotone-close';
import { fadeInUp400ms } from '../../../../../@vex/animations/fade-in-up.animation';
import { stagger60ms } from '../../../../../@vex/animations/stagger.animation';

@Component({
  selector: 'vex-room-details',
  templateUrl: './room-details.component.html',
  styleUrls: ['./room-details.component.scss'],
  animations: [
    stagger60ms,
    fadeInUp400ms
  ]
})
export class RoomDetailsComponent implements OnInit {

  icClose = icClose;

  constructor(private dialogRef: MatDialogRef<RoomDetailsComponent>) { }

  ngOnInit(): void {
  }

}
