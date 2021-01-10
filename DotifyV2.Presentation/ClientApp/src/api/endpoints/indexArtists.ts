import apiRequest from '../apiRequest'
import { ArtistDescritpion } from '../model'

export default async (offset: number, count: number): Promise<ArtistDescritpion[]> => {
  const response = await apiRequest(`/api/artists?offset=${offset}&count=${count}`, 'GET')
  if (response.ok) {
    const result = await response.json() as ArtistDescritpion[]
    return result
  }
  return []
}
