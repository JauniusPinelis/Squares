import { Component, OnInit } from '@angular/core';
import { Subscriber } from 'rxjs';
import { PointsService } from 'src/app/services/points.service';
import Point from 'src/models/point.model';

@Component({
  selector: 'app-points',
  templateUrl: './points.component.html',
  styleUrls: ['./points.component.css']
})
export class PointsComponent implements OnInit {

  constructor(public pointsService: PointsService) { 

    
  }

  ngOnInit(): void {
    this.pointsService.getAll().subscribe((points) => {
this.points = points;
    })
  }

public points: Point[] = [];


}
