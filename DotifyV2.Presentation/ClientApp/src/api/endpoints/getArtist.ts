import apiRequest from '../apiRequest'
import { Artist, ArtistResponse } from '../model'

export default async (artistId: number): Promise<Artist | null> => {
  const response = await apiRequest(`/api/artists/${artistId}`, 'GET')
  if (response.ok) {
    const data = await response.json() as ArtistResponse
    return data
  }
  return null
}
