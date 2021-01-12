import React, { useCallback } from 'react'
import { useHistory } from 'react-router'
import MediaCover from './MediaCover'
import MediaGridItem from './MediaGridItem'

interface Props {
  id: number
  name: string
  picture: string | null
}

export default ({ id, name, picture }: Props) => {
  const history = useHistory()

  const onClick = useCallback(() => {
    history.push(`/artists/${id}`)
  }, [history, id])

  return (
    <MediaGridItem name={name} onClick={onClick} circular>
      <MediaCover
        name={name}
        coverArt={picture}
        circular
      />
    </MediaGridItem>
  )
}
