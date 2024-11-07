import * as moment from 'moment';

export function ChangeEnumToList(enumObj, arrayChoose) {
  for (const [key, value] of Object.entries(enumObj)) {
    if (!Number.isNaN(Number(key))) {
      continue;
    }
    arrayChoose.push({ Id: value, Title: key.replace('_', '') });
  }
}

export function FormatDayVN(input: any) {
  if (!input) {
    return '';
  }

  return moment(new Date(input)).format('DD-MM-YYYY HH:mm:ss');
}

export function FormatDateVN(input: any) {
  return moment(new Date(input)).format('DD-MM-YYYY');
}

export function FormatDayVNNoTimeZone(input: any) {
  return moment.utc(new Date(input)).format('DD-MM-YYYY HH:mm:ss');
}

export function FormatDaySearch(input) {
  return moment(new Date(input)).format('YYYY-MM-DD HH:mm:ss');
}

export function FormatDayInput(input) {
  return moment(new Date(input)).format('YYYY-MM-DDTHH:mm:ss');
}

export function FormatDayNow() {
  return moment(new Date()).format('YYYY-MM-DDTHH:mm:ss');
}

export function FormBuilderConvertData(object) {
  const formData = new FormData();
  Object.keys(object).forEach((key) => formData.append(key, object[key]));
  return formData;
}

export function DownloadActionFile(data: any, filename: string) {
  const downloadedFile = new Blob([data], { type: data.type });
  const a = document.createElement('a');
  a.setAttribute('style', 'display:none;');
  document.body.appendChild(a);
  a.download = filename;
  a.href = URL.createObjectURL(downloadedFile);
  a.target = '_blank';
  a.click();
  document.body.removeChild(a);
}

export function DetectLinkInText(
  input: string,
  className: string,
  style: string
) {
  let match = input.match(
    /(\b(https?|ftp|file):\/\/[-A-Z0-9+&@#\/%?=~_|!:,.;]*[-A-Z0-9+&@#\/%=~_|])/gi
  );
  if (match) {
    match.map((url) => {
      input = input.replace(
        url,
        "<a href='" +
          url +
          "' target='_blank' class='" +
          className +
          "' " +
          style +
          '>' +
          url +
          '</a>'
      );
    });
  }
  return input;
}

export function GetImageOriginalOffsetFromScaleOffset(
  originalWidth: number,
  originalHeight: number,
  scaleWidth: number,
  scaleHeight: number,
  xOffset: any,
  yOffset: any
): any {
  let scaleWidthRatio = scaleWidth / originalWidth;
  let scaleHeightRatio = scaleHeight / originalHeight;

  var x = xOffset / scaleWidthRatio;
  var y = yOffset / scaleHeightRatio;

  return { x: Math.round(x), y: Math.round(y) };
}
