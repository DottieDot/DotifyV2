import { Card, CardContent, CardMedia, Grid, makeStyles, Typography, Button, useTheme, useMediaQuery, Portal } from '@material-ui/core'
import React, { MutableRefObject, ReactElement } from 'react'
import AddPropsWhenScrolled from './AddPropsWhenScrolled'
import LikeButton from './LikeButton'
import { MediaTypes } from '../common'
import { MediaCover } from '.'

const useStyles = makeStyles(theme => ({
  card: {
    position: 'sticky',
    top: 75,
    [theme.breakpoints.down('sm')]: {
      display: 'flex',
      flexDirection: 'row',
    }
  },
  cover: {
    background: theme.palette.primary.main,
    [theme.breakpoints.down('sm')]: {
      width: 100,
      height: '1fr',
    },
    [theme.breakpoints.up('md')]: {

    }
  },
  cardContent: {
    padding: '16px !important',
    [theme.breakpoints.down('sm')]: {
      flex: 1
    }
  },
  playButton: {
    marginBottom: theme.spacing(1)
  }
}))

interface CommonProps {
  title: string
  subtitle?: ReactElement
  image: ReactElement|null
  stickyContainer: MutableRefObject<null>
  type: MediaTypes,
  id: number
}

type LikeProps =
  | { likeable?: false, onLike?: never, liked?: never }
  | { likeable: true, onLike: (liked: boolean) => void, liked: boolean }

type ShareProps =
  | { shareable?: false, onShare?: never }
  | { shareable: true, onShare: () => void }

type PlayProps =
  | { playable?: false, onPlay?: never }
  | { playable: true, onPlay: () => void }

type Props = CommonProps & LikeProps & ShareProps & PlayProps

export default ({ title, subtitle, image, playable, onPlay, shareable, onShare, stickyContainer, type, id }: Props) => {
  const classes = useStyles()
  const theme = useTheme()
  const sticky = useMediaQuery(theme.breakpoints.down('sm'))

  const content = (
    <Card className={classes.card}>
      <CardMedia className={classes.cover}>
        <MediaCover
          name={title}
          coverArt={null}
          variant="flat"
          color="primary"
        />
      </CardMedia>
      <CardContent className={classes.cardContent}>
        <Grid container spacing={2}>
          <Grid item md={12} sm={6}>
            <Typography variant="h5" component="h1">
              {title} <LikeButton type={type} id={id} />
            </Typography>
            <Typography variant="subtitle1" color="textSecondary" gutterBottom>
              {subtitle}
            </Typography>
          </Grid>
          <Grid item xs>
            {playable && (
              <Button
                className={classes.playButton}
                variant="contained"
                color="primary"
                onClick={onPlay}
                fullWidth
              >
                Play
              </Button>
            )}
            {shareable && (
              <Button
                variant="outlined"
                onClick={onShare}
                fullWidth
              >
                Share
              </Button>
            )}
          </Grid>
        </Grid>
      </CardContent>
    </Card>
  )

  if (sticky && stickyContainer.current) {
    return (
      <Portal container={stickyContainer.current}>
        <AddPropsWhenScrolled props={{ elevation: 4 }}>
          {content}
        </AddPropsWhenScrolled>
      </Portal>
    )
  } 
  else {
    return content
  }
}
