import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'numberToArray'
})
export class NumberToArrayPipe implements PipeTransform {

  transform(value: number, ...args: unknown[]): number[] {
    const res = [];
    for (let i = 0; i < value + 1; i++) {
      res.push(i + 1);
    }
    return res;
  }

}
