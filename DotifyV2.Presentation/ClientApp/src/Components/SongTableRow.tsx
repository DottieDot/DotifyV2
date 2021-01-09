import { IconButton, makeStyles, Menu, MenuItem, TableCell, TableRow } from '@material-ui/core'
import { MoreHoriz as MoreHorizIcon } from '@material-ui/icons'
import React, { useCallback, useState, MouseEvent } from 'react'
import { LikeButton } from '.'
import { ArtistDescritpion } from '../api/model'

const useStyles = makeStyles({
  iconButtons: {
    display: 'flex',
  }
})

interface Props {
  songNr: number
  name: string
  duration: number
  songId: number
  artist?: ArtistDescritpion
  management?: boolean
}

export default ({ songNr, name, duration, artist, songId, management }: Props) => {
  const [menuAnchor, setMenuAnchor] = useState<null | HTMLElement>(null)
  const classes = useStyles()
  const seconds = duration % 60

  const openMenu = useCallback((event: MouseEvent<HTMLButtonElement>) => {
    setMenuAnchor(event.currentTarget)
  }, [setMenuAnchor])

  const closeMenu = useCallback(() => {
    setMenuAnchor(null)
  }, [setMenuAnchor])

  return (
    <TableRow>
      <TableCell width={30}>
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
      <TableCell align="right" width={1}>
        <div className={classes.iconButtons}>
          <LikeButton type="song" id={songId} />
          {management && (
            <IconButton size="small" onClick={openMenu}>
              <MoreHorizIcon />
            </IconButton>
          )}
          <Menu
            anchorEl={menuAnchor}
            keepMounted
            open={!!menuAnchor}
            onClose={closeMenu}
          >
            <MenuItem>Test</MenuItem>
            <MenuItem>Test</MenuItem>
            <MenuItem>Test</MenuItem>
          </Menu>
        </div>
      </TableCell>
    </TableRow>
  )
}
