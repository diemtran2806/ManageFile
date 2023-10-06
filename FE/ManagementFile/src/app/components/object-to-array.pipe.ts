import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'objectToArray',
})
export class ObjectToArrayPipe implements PipeTransform {
  transform(value: any): any[] {
    const result = [];
    for (const key in value) {
      if (value.hasOwnProperty(key)) {
        result.push({ key, value: value[key] });
      }
    }
    return result;
  }
}
