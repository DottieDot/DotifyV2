import apiRequest from '../apiRequest'
import { AlbumDescription } from '../model'

export default async (offset: number, count: number): Promise<AlbumDescription[]> => {
  const response = await apiRequest(`/api/albums?offset=${offset}&count=${count}`, 'GET')
  if (response.ok) {
    const result = await response.json() as AlbumDescription[]
    return result
  }
  return []
}
