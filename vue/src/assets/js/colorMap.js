export const colorMap = {
  // Màu cơ bản
  'Đen': '#000000',
  'Trắng': '#FFFFFF',
  'Xám': '#808080',
  'Bạc': '#C0C0C0',

  // Màu đỏ và họ đỏ
  'Đỏ': '#FF0000',
  'Đỏ tươi': '#FF3333',
  'Đỏ đậm': '#CC0000',
  'Đỏ thẫm': '#8B0000',
  'Hồng': '#FFC0CB',
  'Cam': '#FFA500',

  // Màu xanh lá và họ xanh lá
  'Xanh lá': '#00FF00', 
  'Xanh lá đậm': '#008000',
  'Xanh lá nhạt': '#90EE90',
  'Xanh rêu': '#556B2F',
  'Xanh olive': '#808000',

  // Màu xanh dương và họ xanh dương
  'Xanh dương': '#0000FF',
  'Xanh biển': '#000080',
  'Xanh da trời': '#87CEEB',
  'Xanh coban': '#4169E1',
  'Xanh ngọc': '#40E0D0',
  'Xanh navy': '#000080',

  // Màu vàng và họ vàng 
  'Vàng': '#FFFF00',
  'Vàng nhạt': '#FFFFE0',
  'Vàng đậm': '#FFD700',
  'Be': '#F5F5DC',

  // Màu tím và họ tím
  'Tím': '#800080',
  'Tím nhạt': '#E6E6FA',
  'Tím đậm': '#4B0082',

  // Màu nâu và họ nâu
  'Nâu': '#8B4513',
  'Nâu đất': '#A0522D',
  'Nâu nhạt': '#DEB887',
  'Kem': '#FFF8DC',

  // Màu thể thao phổ biến
  'Neon xanh': '#00FF7F',
  'Neon vàng': '#FFFF00',
  'Neon hồng': '#FF69B4',
  'Phản quang': '#F0F0F0',
  'Gradient xanh': 'linear-gradient(45deg, #00ff00, #008000)',
  'Gradient đỏ': 'linear-gradient(45deg, #ff0000, #8b0000)'
}

export const getColorStyle = (color) => {
  return {
    backgroundColor: colorMap[color],
    borderColor: color == 'Trắng' ? '#ddd' : colorMap[color],
    //background: colorMap[color].includes('gradient') ? colorMap[color] : undefined
  }
}