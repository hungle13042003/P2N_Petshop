// This file can be replaced during build by using the `fileReplacements` array.
// `ng build` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
   urlImage: 'https://localhost:44312/ImageUI/',
   apiUrl: 'https://localhost:44312/api/',
  // urlImage: 'http://157.119.251.140:9713/ImageUI/',
  // apiUrl: 'http://157.119.251.140:9713/api/',

  //urlImage: 'https://p2napi.yoot.vn/ImageUI/',
  //apiUrl: 'https://p2napi.yoot.vn/api/',
  defaultToken: ''
};

export const configCKEditor = {
  toolbar: {
    items: [
      'heading',
      '|',
      'bold',
      'italic',
      'underline',
      'alignment',
      'fontbackgroundcolor',
      'fontcolor',
      'fontsize',
      'highlight',
      '|',
      'fontfamily',
      'specialcharacters',
      'pagebreak',
      'horizontalline',
      'link',
      'ckfinder',
      'imageupload',
      'indent',
      'mediaembed',
      'tableproperties',
      'bulletedList',
      'numberedList',
    ],
  },
  image: {
    toolbar: [
      'imageStyle:full',
      'imageStyle:side',
      '|',
      'imageTextAlternative',
    ],
    styles: ['full', 'side'],
  },
  language: 'vi-VN',
  resizeOptions: [
    {
      name: 'imageResize:original',
      label: 'Original',
      value: null,
    },
    {
      name: 'imageResize:50',
      label: '50%',
      value: '50',
    },
    {
      name: 'imageResize:75',
      label: '75%',
      value: '75',
    },
  ],
  fontColor: {
    colors: [
      {
        color: '#1AD4FF',
        label: 'Blue',
      },
      {
        color: '#FF567D',
        label: 'Red',
      },
      {
        color: '#000000',
        label: 'Black',
      },
      {
        color: '#FFFFFF',
        label: 'White',
      },
    ],
  },
};
