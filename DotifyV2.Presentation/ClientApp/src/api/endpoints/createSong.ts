import apiRequest from '../apiRequest'
import { SongResponse } from '../model'

export default async (albumId: number, name: string, duration: number) => {
  const response = await apiRequest('/api/songs', 'POST', {
    album_id: albumId,
    name,
    duration,
  })
  if (response.ok) {
    const result = await response.json() as SongResponse
    return result
  }
  return null
}
