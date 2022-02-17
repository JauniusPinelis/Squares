import { Component, OnInit } from '@angular/core';
import { PointsService } from 'src/app/services/points.service';
import Point from 'src/models/point.model';

@Component({
  selector: 'app-points',
  templateUrl: './points.component.html',
  styleUrls: ['./points.component.css']
})
export class PointsComponent implements OnInit {
  public points: Point[] = [
    ];
  constructor(private pointsService: PointsService) { }

  ngOnInit(): void {
    this.pointsService.getAll().subscribe((pointsData) => {
      this.points = pointsData;
    })
  }
public delete(id: number): void {
  this.pointsService.delete(id).subscribe(()=>{
    this.points = this.points.filter(p => p.id !=id);
  });

  

} 

}
