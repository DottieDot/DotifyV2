import { IconButton, makeStyles, Menu, MenuItem, TableCell, TableRow } from '@material-ui/core'
import { MoreVert as MoreVertIcon } from '@material-ui/icons'
import React, { useCallback, useState, MouseEvent, Fragment } from 'react'
import LikeButton from '../LikeButton'
import { ArtistDescritpion } from '../../api/model'
import DeleteSongDialog from './DeleteSongDialog'
import UpdateSongDialog from './UpdateSongDialog'

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
  onSongDeleted?: (songId: number) => void
  onSongUpdated?: (songId: number, name: string, duration: number) => void
}

export default ({ songNr, name, duration, artist, songId, management, onSongDeleted, onSongUpdated }: Props) => {
  const [menuAnchor, setMenuAnchor] = useState<null | HTMLElement>(null)
  const [deleteSongDialog, setDeleteSongDialog] = useState(false)
  const [updateSongDialog, setUpdateSongDialog] = useState(false)
  const classes = useStyles()
  const seconds = duration % 60

  const openMenu = useCallback((event: MouseEvent<HTMLButtonElement>) => {
    setMenuAnchor(event.currentTarget)
  }, [setMenuAnchor])

  const closeMenu = useCallback(() => {
    setMenuAnchor(null)
  }, [setMenuAnchor])

  const openDeleteSongDialog = useCallback(() => {
    setDeleteSongDialog(true)
    closeMenu()
  }, [setDeleteSongDialog, closeMenu])

  const closeDeleteSongDialig = useCallback((deleted: boolean) => {
    setDeleteSongDialog(false)
    deleted && onSongDeleted && onSongDeleted(songId)
  }, [setDeleteSongDialog, onSongDeleted, songId])

  const openUpdateSongDialog = useCallback(() => {
    setUpdateSongDialog(true)
    closeMenu()
  }, [setUpdateSongDialog, closeMenu])

  const closeUpdateSongDialog = useCallback((name: string | null, duration: number | null) => {
    setUpdateSongDialog(false)
    if (name !== null && duration !== null && onSongUpdated) {
      onSongUpdated(songId, name, duration)
    }
  }, [onSongUpdated, songId, setUpdateSongDialog])

  return (
    <Fragment>
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
                <MoreVertIcon />
              </IconButton>
            )}
            <Menu
              anchorEl={menuAnchor}
              keepMounted
              open={!!menuAnchor}
              onClose={closeMenu}
            >
              <MenuItem onClick={openUpdateSongDialog}>Update</MenuItem>
              <MenuItem onClick={openDeleteSongDialog}>Delete</MenuItem>
            </Menu>
          </div>
        </TableCell>
      </TableRow>
      <DeleteSongDialog
        open={deleteSongDialog}
        onClose={closeDeleteSongDialig}
        songId={songId}
      />
      <UpdateSongDialog
        open={updateSongDialog}
        onClose={closeUpdateSongDialog}
        songId={songId}
        currentName={name}
        currentDuration={duration}
      />
    </Fragment>
  )
}
