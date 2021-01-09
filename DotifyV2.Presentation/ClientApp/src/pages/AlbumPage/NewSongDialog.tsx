import { Button, Dialog, DialogActions, DialogContent, DialogContentText, DialogTitle, TextField } from '@material-ui/core'
import React, { ChangeEvent, FormEvent, useCallback, useState } from 'react'
import { useDispatch } from 'react-redux'
import * as endpoints from '../../api/endpoints'
import { Song } from '../../api/model'
import { showAlert } from '../../store/actions/Alerts'

interface Props {
  open: boolean
  onClose: (song: Song | null) => void
  albumId: number
}

export default ({ open, onClose, albumId }: Props) => {
  const [name, setName] = useState('')
  const [duration, setDuration] = useState('')
  const [submitting, setSubmitting] = useState(false)
  const dispatch = useDispatch()

  const handleClose = useCallback(() => {
    if (!submitting) {
      onClose(null)
      setName('')
      setDuration('')
    }
  }, [submitting, onClose, setName])

  const onNameChange = useCallback((event: ChangeEvent<HTMLInputElement>) => {
    setName(event.target.value)
  }, [setName])

  const onDurationChange = useCallback((event: ChangeEvent<HTMLInputElement>) => {
    setDuration(event.target.value)
  }, [setDuration])

  const onSubmit = useCallback(async (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault()
    setSubmitting(true)
    const song = await endpoints.createSong(albumId, name, +duration)
    if (song) {
      onClose(song)
      setName('')
      setDuration('')
    }
    else {
      dispatch(showAlert('Failed to create song', 'error'))
    }
    setSubmitting(false)
  }, [setSubmitting, name, dispatch, albumId, duration, onClose])

  return (
    <Dialog open={open} onClose={handleClose}>
      <form onSubmit={onSubmit}>
        <DialogTitle>Create Song</DialogTitle>
        <DialogContent>
          <DialogContentText>
            Enter a name & duration for the song.
          </DialogContentText>
          <TextField
            margin="dense"
            label="Name"
            type="text"
            value={name}
            onChange={onNameChange}
            disabled={submitting}
            required
            fullWidth
          />
          <TextField
            margin="dense"
            label="Duration"
            type="number"
            value={duration}
            onChange={onDurationChange}
            disabled={submitting}
            required
            fullWidth
          />
        </DialogContent>
        <DialogActions>
          <Button
            disabled={submitting}
            onClick={handleClose}
            color="primary"
          >
            Cancel
          </Button>
          <Button
            disabled={!name.trim() || !duration || submitting}
            type="submit"
            color="primary"
          >
            Create
          </Button>
        </DialogActions>
      </form>
    </Dialog>
  )
}
