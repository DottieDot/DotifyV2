import apiRequest from '../apiRequest'
import { Album, AlbumResponse } from '../model'

export default async (albumId: number): Promise<Album | null> => {
  const response = await apiRequest(`/api/albums/${albumId}`, 'GET')
  if (response.ok) {
    const data = await response.json() as AlbumResponse
    return data
  }
  return null
}
