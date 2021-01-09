
export default (str: string, count: number) => 
  str
    .split(' ')
    .map(substr => substr[0]?.toUpperCase() ?? '')
    .slice(0, count)
    .join('')
