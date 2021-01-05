import apiRequest from '../apiRequest'
import { AlbumResponse } from '../model'

export default async (name: string) => {
  const response = await apiRequest('/api/albums', 'POST', {
    name
  })
  if (response.ok) {
    const result = await response.json() as AlbumResponse
    return result
  }
  return null
}
