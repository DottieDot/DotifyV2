import { NumberLocale } from "yup/lib/locale";

export default interface AuthenticatedUserResponse {
  id: number
  artist_id: number | null
  username: string
  likes: {
    songs: number[]
    albums: number[]
    artists: number[]
  }
}
