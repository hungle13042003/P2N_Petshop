export const environment = {
  production: false,
  //apiUrl: 'https://localhost:44312/api/',
  apiUrl: 'http://157.119.251.140:9713/api/',
  defaultToken: '<<..P2N--==Pet[]>>21',
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
  language: 'en',
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
