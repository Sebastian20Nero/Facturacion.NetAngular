export const navigation = [
  {
    text: 'Compra',
    path: '/home',
    icon: 'home'
  },
  {
    text: 'Administrador',
    icon: 'folder',
    items: [
      {
        text: 'Clientes',
        path: '/clientes'
      },
      {
        text: 'Productos',
        path: '/productos'
      }
    ]
  }
];
