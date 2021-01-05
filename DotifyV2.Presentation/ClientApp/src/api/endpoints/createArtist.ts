import apiRequest from '../apiRequest'
import { ArtistResponse } from '../model'

export default async (name: string) => {
  const response = await apiRequest('/api/artists', 'POST', {
    name
  })
  if (response.ok) {
    const result = await response.json() as ArtistResponse
    return result
  }
  return null
}
