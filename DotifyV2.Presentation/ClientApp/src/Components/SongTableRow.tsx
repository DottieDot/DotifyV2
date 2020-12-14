import { TableCell, TableRow } from '@material-ui/core'
import React from 'react'
import { ArtistDescritpion } from '../api/model'

interface Props {
  songNr: number
  name: string
  duration: number
  artist?: ArtistDescritpion
}

export default ({ songNr, name, duration, artist }: Props) => {
  const seconds = duration % 60

  return (
    <TableRow>
      <TableCell width="4ch">
        {songNr}
      </TableCell>
      <TableCell>
        {name}
      </TableCell>
      {artist && (
        <TableCell>
          {artist.name}
        </TableCell>
      )}
      <TableCell align="right">
        {Math.floor(duration / 60)}:{seconds < 10 ? `0${seconds}` : seconds}
      </TableCell>
    </TableRow>
  )
}
